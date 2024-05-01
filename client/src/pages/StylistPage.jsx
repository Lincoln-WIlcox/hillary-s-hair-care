import { useEffect, useState } from "react"
import StylistList from "../components/StylistList"
import { getStylists } from "../services/stylistsServices"

const StylistPage = () =>
{
    const [stylists, setStylists] = useState([])

    const fetchAndSetStylists = () =>
    {
        getStylists().then(setStylists)
    }

    useEffect(
        () =>
        {
            fetchAndSetStylists()
        }, []
    ) 

    return <StylistList stylists={stylists} />
}

export default StylistPage