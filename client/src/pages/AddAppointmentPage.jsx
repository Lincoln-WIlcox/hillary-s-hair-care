import EditForm from "../components/EditForm"
import { postAppointment } from "../services/appointmentsServices"

const AddAppointmentPage = () =>
{
    return <EditForm onAppointmentSubmitted={postAppointment} />
}

export default AddAppointmentPage