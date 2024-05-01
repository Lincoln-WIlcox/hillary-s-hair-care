export const getServices = async () =>
{
    return fetch("/api/services").then(res => res.json())
}