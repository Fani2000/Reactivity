import { Button, Container, Menu } from "semantic-ui-react";
import { NavLink } from "react-router-dom";

const Navbar = () => {
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header as={NavLink} to="/">
          <img src="/assets/logo.png" alt="logo" style={{ marginRight: 10 }} />
          Reactivities
        </Menu.Item>

        <Menu.Item as={NavLink} to="/activities" name="Activities"></Menu.Item>

        <Menu.Item as={NavLink} to="/errors" name="Errors"></Menu.Item>

        <Menu.Item>
          <Button
            as={NavLink}
            to="/createActivity"
            positive
            content="Create Activity"
          />
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default Navbar;
