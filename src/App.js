import React from 'react';
import Chatbot from 'react-chatbot-kit'
import './App.css';

import ActionProvider from './ActionProvider';
import MessageParser from './MessageParser';
import config from './config';
import './Chatbot.css';

function App() {
  let date = new Date();
  let startTime = date.getTime();
  sessionStorage.setItem("startTime", startTime);
  return (
    <div className="App">
      <header className="App-header">
        <Chatbot config={config} actionProvider={ActionProvider} messageParser={MessageParser} placeholderText="Escribe un mensaje"/>
      </header>
    </div>
  );
}

export default App;