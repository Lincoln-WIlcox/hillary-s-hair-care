import { useState } from 'react'
import { Outlet, Route, Routes } from 'react-router-dom'
import Navbar from './Navbar'
import Appointments from './pages/Appointments'
import EditPage from './pages/EditPage'
import AddAppointmentPage from './pages/AddAppointmentPage'
import StylistPage from './pages/StylistPage'
import AddStylistPage from './pages/AddStylistPage'
import CustomerPage from './pages/CustomerPage'
import AddCustomerPage from './pages/AddCustomerPage'

function App()
{
  return (
    <Routes>
      <Route path="/" element={
        <>
          <Navbar />
          <Outlet />
        </>
      }>
        <Route index element={<p>home</p>} />
        <Route path="/appointments">
          <Route index element={<Appointments />} />
          <Route path=":appointmentId/edit" element={<EditPage />} />
          <Route path="create" element={<AddAppointmentPage />} />
        </Route>
        <Route path="/stylists">
          <Route index element={<StylistPage />} />
          <Route path="/stylists/create" element={<AddStylistPage />} />
        </Route>
        <Route path="/customers">
          <Route index element={<CustomerPage />} />
          <Route path="/customers/create" element={<AddCustomerPage />} />
        </Route>
      </Route>
    </Routes>
  )
}

export default App
