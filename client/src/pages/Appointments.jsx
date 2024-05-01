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
                setAppointments(appointments)
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
        <AppointmentList appointments={appointments} onAppointmentDeleted={fetchAppointments} />
    )
}

export default Appointments