export const getStylists = async () =>
{
    return fetch("/api/stylists").then(res => res.json())
}

export const getActiveStylists = async () =>
{
    return fetch("/api/stylists?active=true").then(res => res.json())
}

export const postStylist = async (stylist) =>
{
    return fetch("/api/stylists",
        {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(stylist)
        }).then(res => res.json())
}

export const deactivateStylist = async (id) =>
{
    return fetch(`/api/stylists/${id}`,
        {
            method: "DELETE"
        })
}