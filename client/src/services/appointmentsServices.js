
export const getScheduledAppointments = () =>
{
    return fetch("/api/appointments/scheduled").then(res => res.json())
}

export const deleteAppointment = (id) =>
{
    return fetch(`/api/appointments/${id}`,
        {
            method: "DELETE"
        }
    )
}