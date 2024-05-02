
import { useNavigate } from "react-router-dom"
import CustomerForm from "../components/CustomerForm"
import { postCustomer } from "../services/customersServices"

const AddCustomerPage = () =>
{
    const navigate = useNavigate()

    const onCustomerSubmitted = (customer) =>
    {
        postCustomer(customer).then(
            () =>
            {
                navigate("/customers")
            }
        )
    }

    return <CustomerForm onCustomerSubmitted={onCustomerSubmitted} />
}

export default AddCustomerPage