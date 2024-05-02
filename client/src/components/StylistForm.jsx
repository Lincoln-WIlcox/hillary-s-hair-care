import { useState } from "react"

const StylistForm = () =>
{
    const [stylistName, setStylistName] = useState("")

    return <div>
        <input type="text" placeholder="stylist name" value={stylistName} onChange={(event) => setStylistName(event.target.value)} />
    </div>
}

export default StylistForm