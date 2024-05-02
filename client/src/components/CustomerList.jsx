const CustomerList = ({ customers }) =>
{
    return <div>
        {
            customers?.map(customer =>
                <span>{customer.name}</span>)
        }
    </div>
}

export default CustomerList