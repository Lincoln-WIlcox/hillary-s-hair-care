import { Fragment } from "react"
import { useNavigate } from "react-router-dom"


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
                                        
                                        onStylistDeleted()
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