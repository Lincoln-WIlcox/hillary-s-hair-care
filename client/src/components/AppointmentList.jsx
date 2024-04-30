

const AppointmentList = ({ appointments }) =>
{
    return (
        <div>
            {
                appointments.map(appointment =>
                {
                    return (
                        <div>
                            <span>{appointment.scheduledDate}</span>
                            <span>{appointment.stylist.name}</span>
                            <span>{appointment.customer.name}</span>
                            <span>{appointment.totalPrice}</span>
                            <div>
                                {
                                    appointment.services.map(service =>
                                    {
                                        return (
                                            <>
                                                <span>{service.name}</span>
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