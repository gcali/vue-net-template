import { apiConfig } from "../configuration";
import router from "../router";
import { store } from "../store";

const baseUrl = apiConfig.baseUrl;

type Params = { [key: string]: string };

const urlBuilder = (action: string, params?: Params) => {
    const mainUrl = baseUrl + action;
    if (params) {
        const flatParams = Object.keys(params).map(k => ({ k, v: params[k] }));
        return mainUrl + "?" + flatParams.map(p => `${encodeURI(p.k)}=${encodeURI(p.v)}`).join("&");
    }
    return mainUrl;
}


const isFormData = (e: unknown): e is FormData => {
    return e instanceof FormData;
}

export const withLoading = async (inner: () => Promise<void>): Promise<void> => {
    store.loading++;
    try {
        await inner();
    } finally {
        store.loading--;
    }
}

const fetchWrapper = async (action: string, type: "GET" | "POST" | "PUT" | "DELETE", data?: {
    body?: unknown,
    params?: Params
}): Promise<Response> => {
    store.loading++;
    let hasRedirected = false;
    try {
        const params = data && data.params;
        const body = data && data.body ? (((typeof data.body === "string") || isFormData(data.body)) ? data.body : JSON.stringify(data.body)) : undefined;
        const headers: HeadersInit = {
            "X-Requested-With": "XMLHttpRequest",
        };
        if (!isFormData(data?.body)) {
            headers["content-type"] = "application/json";
        }
        const result = await fetch(urlBuilder(action, params), {
            method: type,
            body: body,
            credentials: 'include',
            headers
        });
        if (!result.ok && result.status === 401) {
            store.user = undefined;
            hasRedirected = true;
            router.push({ name: "login" });
        }
        return result;
    }
    catch (e) {
        if (!hasRedirected && router.currentRoute.name !== "login") {
            console.log(router.currentRoute);
            router.push({ name: "login" });
        }
        throw e;
    } finally {
        store.loading--;
    }
};

export const api = {
}

function wrapFile(file: File) {
    const data = new FormData();
    data.append('file', file);
    return data;
}

function getFilename(rawResponse: Response, defaultFilename: string) {
    const header = rawResponse.headers.get('Content-Disposition');
    const filename = header ? header.split(";")[1].split("=")[1] : defaultFilename;
    return filename;
}
