
export const getScheduledAppointments = async () =>
{
    return fetch("/api/appointments/scheduled").then(res => res.json())
}

export const deleteAppointment = async (id) =>
{
    return fetch(`/api/appointments/${id}`,
        {
            method: "DELETE"
        }
    )
}

export const getServicesForAppointment = async (id) =>
{
    return fetch(`/api/appointments/${id}/services`).then(res => res.json())
}