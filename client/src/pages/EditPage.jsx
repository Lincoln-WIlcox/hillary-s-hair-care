import { useParams } from "react-router-dom"
import EditForm from "../components/EditForm"
import { putAppointment } from "../services/appointmentsServices"

const EditPage = () =>
{
    const { appointmentId } = useParams()

    const onAppointmentSubmitted = (appointment) =>
    {
        appointment.id = appointmentId
        putAppointment(appointment)
    }

    return <EditForm appointmentId={appointmentId} onAppointmentSubmitted={onAppointmentSubmitted} />
}

export default EditPage