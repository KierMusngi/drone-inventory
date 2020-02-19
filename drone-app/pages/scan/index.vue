<template>
<div>
  <v-layout row wrap px-12 pt-12>
    <v-flex md12>
      <h1 class="white--text">QR Scanner</h1>
    </v-flex>
  </v-layout>

  <v-layout>
    <v-flex md12 pa-5>
    </v-flex>  
  </v-layout>

  <v-layout px-12>
    <v-flex md12>
      <v-card class="elevation-12">
        <v-card-text>
          <v-text-field
            label="Name"
            type="text"
            v-model="name"
            readonly
            placeholder=" "
          ></v-text-field>
          <v-text-field
            label="Description"
            type="text"
            v-model="description"
            readonly
            placeholder=" "
          ></v-text-field>
          <v-text-field
            label="Serial Number"
            type="text"
            v-model="serialNumber"
            readonly
            placeholder=" "
          ></v-text-field>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout> 

  <v-layout px-12>
    <v-flex md12>
      <v-btn 
        @click="save" 
        block 
        rounded
        color="#26B47F" 
        class="white--text"
        :disabled='this.name === ""'
      >Accept</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout> 

  <v-layout px-12>
    <v-flex md12>
      <v-btn 
        @click="clear" 
        block 
        rounded
        color="#CE1127" 
        class="white--text" 
        :disabled='this.name === ""'
      >Decline</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout>

  <v-snackbar
      v-model="snackbar"
      color="green"
      :timeout=2000
      top
    >
      {{ text }}
    </v-snackbar>
</div>
</template>

<script>
const signalR = require('@microsoft/signalr')

export default {
  data: () => ({
    name : "",
    description : "",
    serialNumber: "",
    connection: {},
    snackbar: false,
    text: "Container successfully added."
  }),
  created(){
    this.connection = new signalR.HubConnectionBuilder()
        .withUrl(process.env.SIGNALR_BASE_URL + '/scannerHub')
        .withAutomaticReconnect()
        .build();

    this.connection.start().then(() => {
    }).catch(function (err) {
      return console.error(err.toString());
    });
  },
  mounted(){
    var thisVue = this
    thisVue.connection.on("receive", function (name, description, serialNumber) {
        thisVue.name = name
        thisVue.description = description
        thisVue.serialNumber = serialNumber
    });
  },
  methods:{
    clear(){
      this.name = ""
      this.description = ""
      this.serialNumber = ""
    },
    save(){
      this.$axios.$post(`${process.env.API_BASE_URL}/containers/`, {
        name : this.name,
        description : this.description,
        serialNumber : this.serialNumber
      }).then((result) => {
        this.clear();
        this.snackbar = true
      }).catch((err) => {
        console.log(err);
      });
    }
  }
}
</script>

<style>

</style>