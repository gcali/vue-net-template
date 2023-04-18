if (!process.env.VUE_APP_API_URL) {
    throw new Error("No api url configured");
}
export const apiConfig = {
    baseUrl: process.env.VUE_APP_API_URL as string
}