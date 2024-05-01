import { useParams } from "react-router-dom"
import EditForm from "../components/EditForm"
import { putAppointment } from "../services/appointmentsServices"

const EditPage = () =>
{
    const { appointmentId } = useParams()

    return <EditForm appointmentId={appointmentId} onAppointmentSubmitted={putAppointment} />
}

export default EditPage