import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { List, Header } from "semantic-ui-react";

const App = () => {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios
      .get("http://localhost:5000/api/activities")
      .then((res) => {
        setActivities(res.data);
      })
      .catch((err) => {});
  }, []);

  return (
    <div>
      <Header as="h2" icon="users" content="Reactivities"></Header>
      <List>
        {activities.map((activity: any) => {
          return <List.Item key={activity.id}>{activity.title}</List.Item>;
        })}
      </List>
    </div>
  );
};

export default App;
