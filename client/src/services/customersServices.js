export const getCustomers = async () =>
{
    return fetch("/api/customers").then(res => res.json())
}