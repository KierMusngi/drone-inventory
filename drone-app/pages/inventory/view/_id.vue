<template>
<div>
  <v-layout row wrap px-12 pt-12>
    <v-flex md12>
      <h1 class="white--text">View Container</h1>
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
            label="Serial Number"
            type="text"
            v-model="serialNumber"
            readonly
          ></v-text-field>
          <v-text-field
            label="Name"
            type="text"
            v-model="name"
            readonly
          ></v-text-field>
          <v-text-field
            label="Description"
            type="text"
            v-model="description"
            readonly
          ></v-text-field>
          <v-text-field
            label="Box Count"
            type="text"
            v-model="boxCount"
            readonly
          ></v-text-field>
          <v-text-field
            label="Item Count"
            type="text"
            v-model="itemCount"
            readonly
          ></v-text-field>
          <v-text-field
            label="Expiration Date"
            type="text"
            v-model="expirationDate"
            readonly
          ></v-text-field>
          <v-text-field
            label="Manufacturing Date"
            type="text"
            v-model="manufacturingDate"
            readonly
          ></v-text-field>
          <v-text-field
            label="Date Created"
            type="text"
            v-model="dateCreated"
            readonly
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
        to="/inventory" 
        block 
        color="#26B47F" 
        dark
        rounded
      >Back</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout>

  <v-layout px-12>
    <v-flex md12>
      <v-btn
        block
        color="#CE1127" 
        dark
        rounded
        @click.stop="deleteDialog = true"
      >
        Delete
      </v-btn>
      <v-dialog
        v-model="deleteDialog"
        max-width="500"
      >
        <v-card>
          <v-card-title>Are you sure you want to delete this container?</v-card-title>
  
          <v-card-actions>
            <v-spacer></v-spacer>
  
            <v-btn
              color="#26B47F"
              text
              rounded
              @click="deleteDialog = false"
            >
              No
            </v-btn>
  
            <v-btn
              color="#CE1127"
              text
              rounded
              @click="() => 
              {
                this.deleteContainer()
                deleteDialog = false
              }"
            >
              Yes
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-flex>    
  </v-layout>

  <v-layout>
      <v-flex md12 pa-2>
      </v-flex>
    </v-layout>
  
   <v-snackbar
      v-model="snackbar"
      color="red"
      :timeout=2000
      top
    >
      {{ text }}
    </v-snackbar>
</div>
</template>

<script>
export default {
  data: () => ({
    name : "",
    description : "",
    serialNumber: "",
    dateCreated: "",
    boxCount: 0,
    itemCount: 0,
    expirationDate: "",
    manufacturingDate: "",
    deleteDialog: false,
    snackbar: false,
    text: "Container successfully deleted."
  }),
  mounted(){
    this.getContainer()
  },
  methods :{
    getContainer(){
      this.$axios.$get(`${process.env.API_BASE_URL}/containers/` + this.$route.params.id).then((result) => {
        this.name = result.name,
        this.description = result.description,
        this.serialNumber = result.serialNumber,
        this.dateCreated = result.dateCreated,
        this.boxCount = result.boxCount
        this.itemCount = result.itemCount,
        this.expirationDate = result.expirationDate,
        this.manufacturingDate = result.manufacturingDate
      }).catch((err) => {
        console.log(err);
      });
    },
    deleteContainer(){
      this.$axios.$delete(`${process.env.API_BASE_URL}/containers/` + this.$route.params.id).then(() => {
        this.snackbar = true
        setTimeout(() => {  this.$nuxt.$router.replace({path : '/inventory'}); }, 500);
      }).catch((err) => {
        console.log(err);
      });
    },
    toggleEditMode(){
      this.editMode = !this.editMode;
      if(this.editMode){
        this.getContainer();
      }
    }
  }
}
</script>

<style>

</style>