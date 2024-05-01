import { useEffect, useState } from "react"
import { getStylists } from "../services/stylistsServices"
import { getCustomers } from "../services/customersServices"
import { getServices } from "../services/servicesServices"
import { getServicesForAppointment } from "../services/appointmentsServices"

const EditForm = ({ appointmentId }) =>
{
    const [allStylists, setAllStylists] = useState([])
    const [allCustomers, setAllCustomers] = useState([])
    const [allServices, setAllServices] = useState([])
    const [selectedServiceIds, setSelectedServiceIds] = useState([])
    const [selectedStylistId, setSelectedStylist] = useState(0)
    const [selectedCustomerId, setSelectedCustomerId] = useState(0)

    const fetchAndSetState = () =>
    {
        getStylists().then(setAllStylists)
        getCustomers().then(setAllCustomers)
        getServices().then(setAllServices)
        getServicesForAppointment(appointmentId).then((services) => setSelectedServiceIds(services.map(service => service.id)))
    }

    useEffect(
        () =>
        {
            fetchAndSetState()
        }, [appointmentId]
    )

    return <div>
        {
            allServices.map(service =>
                <div key={"srv" + service.id}>
                    <input type="checkbox" value={service.id} checked={selectedServiceIds.find(serviceId => serviceId == service.id) ? true : false} onChange={(event) => 
                    {
                        if(selectedServiceIds.find(serviceId => serviceId == service.id)) 
                        {
                            setSelectedServiceIds(selectedServiceIds.filter(serviceId => serviceId != service.id))
                        } else
                        {
                            setSelectedServiceIds([...selectedServiceIds, service.id])
                        }
                    }} name={"srv" + service.id} />
                    <label htmlFor={"srv" + service.id}>{service.name}</label>
                </div>
            )
        }
        <select onChange={
            (event) =>
            {
                setSelectedStylist(event.target.value)
            }
        }>
            <option value={0}>Choose a stylist</option>
            {
                allStylists.map(stylist =>
                    <option value={stylist.id} key={"st" + stylist.id}>{stylist.name}</option>
                )
            }
        </select>
        <select onChange={
            (event) =>
            {
                setSelectedCustomerId(event.target.value)
            }
        }>
            <option value={0}>Choose a customer</option>
            {
                allCustomers.map(customer =>
                    <option value={customer.id} key={"st" + customer.id}>{customer.name}</option>
                )
            }
        </select>
    </div>
}

export default EditForm