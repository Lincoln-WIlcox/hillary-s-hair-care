const CustomerList = ({ customers }) =>
{
    return <div>
        {
            customers?.map(customer =>
                <span key={"c" + customer.id}>{customer.name}</span>)
        }
    </div>
}

export default CustomerList