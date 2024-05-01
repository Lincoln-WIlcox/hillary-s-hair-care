import { Fragment } from "react"
import { deleteAppointment } from "../services/appointmentsServices"
import { useNavigate } from "react-router-dom"


const AppointmentList = ({ appointments, onAppointmentDeleted }) =>
{
    const navigate = useNavigate()

    return (
        <div>
            {
                appointments.map(appointment =>
                    <Fragment key={"ap" + appointment.id}>
                        <div>
                            <span>{appointment.scheduledDateText}</span>
                            <span>{appointment.stylist.name}</span>
                            <span>{appointment.customer.name}</span>
                            <span>{appointment.totalPrice}</span>
                            <div>
                                {
                                    appointment.appointmentServices.map(appointmentService =>
                                    {
                                        return (
                                            <Fragment key={"aps" + appointmentService.id}>
                                                <span>{appointmentService.service.name}</span>
                                            </Fragment>
                                        )
                                    }
                                    )
                                }
                            </div>
                            <button
                                value={appointment.id}
                                onClick={
                                    (event) => 
                                    {
                                        deleteAppointment(event.target.value).then(onAppointmentDeleted)
                                    }
                                }>delete</button>
                        </div>
                        <button
                            onClick={
                                (event) =>
                                {
                                    navigate(`/appointments/${appointment.id}/edit`)
                                }
                            }
                        >edit</button>
                    </Fragment>
                )
            }
        </div>
    )
}

export default AppointmentList