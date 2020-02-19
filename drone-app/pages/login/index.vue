<template>
  <v-container
        class="fill-height"
        fill-height
        fluid
    >
        <v-layout align-center justify-center>
            <v-row
                align="center"
                justify="center"
            >
            <v-col
                cols="12"
                sm="8"
                md="4"
                lg="4"
            >
            <v-card 
                class="elevation-12"
            >
            <v-col class="pr-12 pl-12">
              <v-row align="center">
                <v-col>
                  <v-row align="start" justify="center">
                    <v-icon large>mdi-qrcode</v-icon>
                  </v-row>
                  <v-row align="start" justify="center">
                    <span
                      class="
                        subtitle-1 
                        font-weight-light 
                        text-color text-center"
                    >Drone Inventory System</span>
                  </v-row>
                </v-col>
              </v-row>
            </v-col>
              <v-card-text>
                <v-form>
                  <v-text-field
                    ref="focusMe"
                    label="Username"
                    name="username"
                    type="text"
                    class="pr-5 pl-5"
                    v-model="username"
                  />
                  <v-text-field
                    id="password"
                    label="Password"
                    name="password"
                    type="password"
                    class="pr-5 pl-5"
                    v-model="password"
                  />
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-col class="pr-6 pl-6">
                  <v-btn 
                      class="elevation-10"
                      block 
                      rounded
                      color="#26B47F"
                      @click="login"
                  >Login</v-btn>
                </v-col>
              </v-card-actions>
            </v-card>
            </v-col>
            </v-row>
        </v-layout>
        <v-snackbar
          v-model="invalidUser"
          color="red"
          :timeout=1000
          top
        >
          {{ text }}
        </v-snackbar>
    </v-container>
</template>

<script>
export default {
  layout: 'login',
  data(){
    return{
      username : "",
      password : "",
      invalidUser: false,
      text: "Invalid user."
    };
  },
  mounted(){
    this.focusInput()
  },
  methods:{
    login(){
      this.$auth.loginWith('local', {
        data : {
          username : this.username,
          password : this.password  
        }
      }).then(() => {
      }).catch(() => {
        this.invalidUser = true
      });
    },
    focusInput() {
      this.$refs.focusMe.focus();
    }
  }
}
</script>

<style>

</style>