export class Authenticator {
  token: string = '';
  getToken(){
    const token = localStorage.getItem('token');
    if (token){
      return token;
    } else return token;
  }

  setToken(token:string, rememberme: boolean){
    this.token = token;
    if (rememberme){
      localStorage.setItem('token', token);
    }
  }

  removeToken(){
    this.token = '';
    localStorage.removeItem('token');
  }
}
