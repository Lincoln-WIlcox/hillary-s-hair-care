import { useEffect, useState } from "react"
import StylistList from "../components/StylistList"
import { getActiveStylists } from "../services/stylistsServices"

const StylistPage = () =>
{
    const [stylists, setStylists] = useState([])

    const fetchAndSetStylists = () =>
    {
        getActiveStylists().then(setStylists)
    }

    useEffect(
        () =>
        {
            fetchAndSetStylists()
        }, []
    )

    return <StylistList stylists={stylists} onStylistDeleted={fetchAndSetStylists} />
}

export default StylistPage