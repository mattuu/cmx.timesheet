export function getCurrentPath(): string {
    return __moduleName.slice(0, __moduleName.lastIndexOf("/") + 1);
}

export function concatToCurrentPath(fragment: string): string {
    return getCurrentPath() + fragment;
}