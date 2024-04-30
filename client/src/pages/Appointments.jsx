import { useEffect, useState } from "react"
import AppointmentList from "../components/AppointmentList"
import { getScheduledAppointments } from "../services/appointmentsServices"

const Appointments = () =>
{
    const [appointments, setAppointments] = useState([])

    const fetchAppointments = () =>
    {
        getScheduledAppointments().then(
            (appointments) =>
            {
                console.log(appointments)
            }
        )
    }

    useEffect(
        () =>
        {
            fetchAppointments()
        }, []
    )


    return (
        <AppointmentList appointments={appointments} />
    )
}

export default Appointments