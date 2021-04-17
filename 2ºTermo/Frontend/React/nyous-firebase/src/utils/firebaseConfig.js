import firebase from 'firebase'

//comandos de configuração gerados pelo firebase no site do projeto
const firebaseConfig = {
    apiKey: "AIzaSyDLYRAew61V3ASMEOCLqx85GygRdTkkB7g",
    authDomain: "nyous-lucax.firebaseapp.com",
    projectId: "nyous-lucax",
    storageBucket: "nyous-lucax.appspot.com",
    messagingSenderId: "302704462830",
    appId: "1:302704462830:web:71fa892ff6005135ef5cff"
  };

//setamos a utlização da configuração para a aplicação
const app = firebase.initializeApp(firebaseConfig);

//Para utilizar o firestore nas páginas
export const db = app.firestore();

export default firebaseConfig;