

const AppointmentList = ({ appointments }) =>
{
    return (
        <div>
            {
                appointments.map(appointment =>
                {
                    return (
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
                                            <>
                                                <span>{appointmentService.service.name}</span>
                                            </>
                                        )
                                    }
                                    )
                                }
                            </div>
                        </div>
                    )
                }
                )
            }
        </div>
    )
}

export default AppointmentList