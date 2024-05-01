import { useState } from 'react'
import { Outlet, Route, Routes } from 'react-router-dom'
import Navbar from './Navbar'
import Appointments from './pages/Appointments'
import EditPage from './pages/EditPage'
import AddAppointmentPage from './pages/AddAppointmentPage'

function App()
{
  const [count, setCount] = useState(0)

  return (
    <Routes>
      <Route path="/" element={
        <>
          <Navbar />
          <Outlet />
        </>
      }>
        <Route index element={<p>home</p>} />
        <Route path="/appointments" element={<Appointments />} />
        <Route path="/appointments/:appointmentId/edit" element={<EditPage />} />
        <Route path="/appointments/create" element={<AddAppointmentPage />} />
      </Route>
    </Routes>
  )
}

export default App
