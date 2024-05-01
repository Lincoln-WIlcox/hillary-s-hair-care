
export const getScheduledAppointments = async () =>
{
    return fetch("/api/appointments/scheduled").then(res => res.json())
}

export const getServicesForAppointment = async (id) =>
{
    return fetch(`/api/appointments/${id}/services`).then(res => res.json())
}

export const postAppointment = async (appointment) =>
{
    return fetch(`/api/appointments`,
        {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(appointment)
        })
}

export const putAppointment = async (appointment) =>
{
    return fetch(`/api/appointments/${appointment.id}`,
        {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(appointment)
        })
}

export const deleteAppointment = async (id) =>
{
    return fetch(`/api/appointments/${id}`,
        {
            method: "DELETE"
        }
    )
}