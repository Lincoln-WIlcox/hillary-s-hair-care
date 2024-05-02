import { useEffect, useState } from "react"
import CustomerList from "../components/CustomerList"
import { getCustomers } from "../services/customersServices"

const CustomerPage = () =>
{
    const [customers, setCustomers] = useState()

    const fetchAndSetCustomers = () =>
    {
        getCustomers().then(setCustomers)
    }

    useEffect(
        () =>
        {
            fetchAndSetCustomers()
        }, []
    )

    return <CustomerList customers={customers} />
}

export default CustomerPage