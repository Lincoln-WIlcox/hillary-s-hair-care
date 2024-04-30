
export const getScheduledAppointments = () =>
{
    return fetch("/appointments/scheduled").then(res => res.json())
}