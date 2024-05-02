import { useState } from "react"

const StylistForm = () =>
{
    const [stylistName, setStylistName] = useState("")

    const onSubmitClicked = () =>
    {
        if(formIsValid())
        {
            
        } else
        {
            window.alert("form is invalid")
        }
    }

    const formIsValid = () =>
    {
        return stylistName != ""
    }

    return <div>
        <input type="text" placeholder="stylist name" value={stylistName} onChange={(event) => setStylistName(event.target.value)} />
        <button onClick={onSubmitClicked}>Submit</button>
    </div>
}

export default StylistForm