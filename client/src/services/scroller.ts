let navbarSize = 0;

export const registerNavbar = (e: HTMLElement): void => {
    navbarSize = parseFloat(window.getComputedStyle(e).height);
}

export const scrollDownByNavbar = (): void => {
    window.scrollBy({top: -navbarSize});
};