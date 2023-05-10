import { useState, useEffect } from 'react'

function Cats() {
  const [cats, setCats] = useState([])
  const [applications, setApplications] = useState([])

  const memberId = 3
  useEffect(() => {
    const fetchData = async () => {
      try{
          let response = await fetch('https://localhost:5001/api/adoptionapplications');
          console.log(response.data)
          let data = await response.json()
          setApplications(data);
      }
      catch(error){
          console.log(error)
            }
          }
    fetchData();
  }, []);
  useEffect(() => {
    const fetchData = async () => {
      try {
        let response = await fetch('https://localhost:5001/api/cats');
        let data = await response.json()
        if(response.ok){
            setCats(data);
        }else{
            throw {error: data.error}
        }
      } catch (err) {
        console.log(err);
      } 
    }
    fetchData();
  }, []);

  const Adopt = async (catId) => {

    try {
        await fetch(`https://localhost:5001/api/adoptionapplications`, { 
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({ MemberId:memberId, CatId:catId })
          });
    } catch (err) {
        alert("Something went wrong with your application")
    }
  };


  return (
    <>
      <div className="card">
        {cats?.map(cat => (
          <div key={cat.id} className="card-body">
            <h3 className="card-title">{cat.name}</h3>
            <p className="card-text">
          <strong>Color:</strong> {cat.color}<br />
          <strong>Sex:</strong> {cat.sex}<br />
          <strong>City:</strong> {cat.city.name}<br />
          <strong>Country:</strong> {cat.city.country}<br />
          <strong>Personality:</strong> {cat.personality ? cat.personality.join(', ') : 'unknown'}<br />
          <strong>Disability:</strong> {cat.disability}<br />
        </p>
            <button onClick={() => Adopt(cat.id)} className="btn btn-primary">Adopt</button>
          </div>
        ))}
      </div>
      <h3>AdoptionApplications</h3>
 <div className="card">
        {applications?.map(application => (
          <div key={application.id} className="card-body">
            <h3 className="card-title">{application.mustBeApprovedByAnotherMember}</h3>
            <p className="card-text">
          <strong>Created:</strong> {new Date(application.createdAt).toLocaleDateString()}<br />
          <strong>Status:</strong> {application.status}<br />
        </p>
          </div>
        ))}
      </div>
    </>
  )
}

export default Cats
