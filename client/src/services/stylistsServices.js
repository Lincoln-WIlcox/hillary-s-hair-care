export const getStylists = async () =>
{
    return fetch("/api/stylists").then(res => res.json())
}

export const getActiveStylists = async () =>
{
    return fetch("/api/stylists?active=true").then(res => res.json())
}

export const deactivateStylist = async (id) =>
{
    return fetch(`/api/stylists/${id}`,
        {
            method: "DELETE"
        })
}