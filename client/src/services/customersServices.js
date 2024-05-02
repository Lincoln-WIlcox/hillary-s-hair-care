export const getCustomers = async () =>
{
    return fetch("/api/customers").then(res => res.json())
}

export const postCustomer = async (customer) =>
{
    return fetch("/api/customers",
        {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(customer)
        }).then(res => res.json())
}