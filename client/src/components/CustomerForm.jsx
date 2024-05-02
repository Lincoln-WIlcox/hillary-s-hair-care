import { useState } from "react"

const CustomerForm = ({ onCustomerSubmitted }) =>
{
    const [customerName, setCustomerName] = useState("")

    const onSubmitClicked = () =>
    {
        if(formIsValid())
        {
            const customer =
            {
                name: customerName
            }

            onCustomerSubmitted(customer)
        } else
        {
            window.alert("form is invalid")
        }
    }

    const formIsValid = () =>
    {
        return customerName != ""
    }

    return <div>
        <input type="text" placeholder="customer name" value={customerName} onChange={(event) => setCustomerName(event.target.value)} />
        <button onClick={onSubmitClicked}>Submit</button>
    </div>
}

export default CustomerForm