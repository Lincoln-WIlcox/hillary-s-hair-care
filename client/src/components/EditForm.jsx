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
    </div>
}

export default EditForm