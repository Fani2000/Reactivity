import React from "react";
import { Dimmer, Loader } from "semantic-ui-react";

interface Props {
  inverted?: boolean;
  context?: string;
}

// prettier-ignore
const LoadingComponent = ({inverted=true,context="Loading..."}: Props) => {
  return (
    <Dimmer active={true} inverted={inverted}>
        <Loader content={context} />
    </Dimmer>
  )
}

export default LoadingComponent;
