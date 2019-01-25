<template>
    <div class="loginpage">
        <form v-if="loginForm" @submit.prevent="login">
            <h1>Get Started With Us!</h1>
            <input type="email" v-model="creds.email" placeholder="email" class="form-control" autofocus>
            <input type="password" v-model="creds.password" placeholder="password" class="form-control">
            <button class="btn btn-sm btn-info" type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <h1>Get Started With Us!</h1>
            <input type="text" v-model="newUser.username" placeholder="name" class="form-control" autofocus>
            <input type="email" v-model="newUser.email" placeholder="email" class="form-control">
            <input type="password" v-model="newUser.password" placeholder="password" class="form-control">
            <button class="btn btn-sm btn-info" type="submit">Register</button>
        </form>
        <div @click="loginForm = !loginForm">
            <h6 class="click-text" v-if="loginForm">No account?
                <br><br><b>Click <a class="a-text">HERE</a> to Register</b></h6>
            <h6 class="click-text" v-else>Already have an account?
                <br><br><b>Click <a>HERE</a> to Sign In</b></h6>
        </div>
    </div>
</template>

<script>
    export default {
        name: "login",
        mounted() {
            this.$store.dispatch("authenticate")
        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            login() {
                this.$store.dispatch("login", this.creds);
            },
            logout() {
                this.$store.dispatch("logout")
            }
        }
    };
</script>
<style scoped>
    form {
        margin-left: 20vw;
        margin-right: 20vw;
        margin-top: 30vh;
    }

    .click-text {
        color: black;
    }

    a:hover {
        cursor: pointer;
    }
</style>