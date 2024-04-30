import { useState } from 'react'
import { Outlet, Route, Routes } from 'react-router-dom'
import Navbar from './Navbar'

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

      </Route>
    </Routes>
  )
}

export default App
