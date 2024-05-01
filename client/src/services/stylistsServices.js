export const getStylists = async () =>
{
    return fetch("/api/stylists").then(res => res.json())
}