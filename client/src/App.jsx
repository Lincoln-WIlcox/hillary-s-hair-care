import { useState } from 'react'
import { Outlet, Route, Routes } from 'react-router-dom'
import Navbar from './Navbar'
import Appointments from './pages/Appointments'

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
        <Route path="/appointments/edit" element={<p>edit page</p>} />
      </Route>
    </Routes>
  )
}

export default App
