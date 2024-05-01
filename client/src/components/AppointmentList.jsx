import { Fragment } from "react"


const AppointmentList = ({ appointments }) =>
{
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
                        </div>
                    </Fragment>
                )
            }
        </div>
    )
}

export default AppointmentList