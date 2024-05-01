import { useParams } from "react-router-dom"
import EditForm from "../components/EditForm"

const EditPage = () =>
{
    const { appointmentId } = useParams()

    return <EditForm />
}

export default EditPage