import { Link } from "react-router-dom"


const Navbar = () =>
{
    return (
        <Link to="/appointments">
            <button>Appointments</button>
        </Link>
    )
}

export default Navbar