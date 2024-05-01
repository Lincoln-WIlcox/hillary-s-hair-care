import { Fragment } from "react"
import { deactivateStylist } from "../services/stylistsServices"


const StylistList = ({ stylists, onStylistDeleted }) =>
{
    return (
        <div>
            {
                stylists.map(stylist =>
                    <Fragment key={"ap" + stylist.id}>
                        <div>
                            <span>{stylist.name}</span>
                            <button
                                value={stylist.id}
                                onClick={
                                    (event) => 
                                    {
                                        deactivateStylist(stylist.id).then(onStylistDeleted)
                                    }
                                }>delete</button>
                        </div>
                    </Fragment>
                )
            }
        </div>
    )
}

export default StylistList