import { useNavigate } from "react-router-dom"
import StylistForm from "../components/StylistForm"
import { postStylist } from "../services/stylistsServices"

const AddStylistPage = () =>
{
    const navigate = useNavigate()

    const onStylistSubmitted = (stylist) =>
    {
        postStylist(stylist).then(
            () =>
            {
                navigate("/stylists")
            }
        )
    }

    return <StylistForm onStylistSubmitted={onStylistSubmitted} />
}

export default AddStylistPage