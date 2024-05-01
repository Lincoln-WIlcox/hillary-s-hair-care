
export const getScheduledAppointments = () =>
{
    return fetch("/api/appointments/scheduled").then(res => res.json())
}