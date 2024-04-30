import { useState } from 'react'
import { Outlet, Route, Routes } from 'react-router-dom'

function App()
{
  const [count, setCount] = useState(0)

  return (
    <Routes>
      <Route path="/" element={
        <>
          <Outlet />
        </>
      }>

      </Route>
    </Routes>
  )
}

export default App
