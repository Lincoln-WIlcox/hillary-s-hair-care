import { Link } from "react-router-dom"

const Navbar = () =>
{
    return (
        <>
            <Link to="/appointments/create">
                <button>Add Appointment</button>
            </Link>
            <Link to="/appointments">
                <button>View Appointments</button>
            </Link>
            <Link to="/stylists/create">
                <button>Add Stylists</button>
            </Link>
            <Link to="/stylists">
                <button>View Stylists</button>
            </Link>
            <Link to="/customers/create">
                <button>Add Customers</button>
            </Link>
            <Link to="/stylists">
                <button>View Stylists</button>
            </Link>
        </>
    )
}

export default Navbar