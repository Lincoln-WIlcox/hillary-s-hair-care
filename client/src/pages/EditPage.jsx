import { useParams } from "react-router-dom"

const EditPage = () =>
{
    const { appointmentId } = useParams()

    return <p>{appointmentId}</p>
}

export default EditPage